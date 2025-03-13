<script setup lang="ts">
import { ref, watch, computed } from "vue";

const props = defineProps<{
  title: string;
  message: string;
  type: "info" | "warning" | "error" | "matchFound";
  isOpen: boolean;
}>();

const emit = defineEmits<{
  (e: "update:isOpen", value: boolean): void;
  (e: "confirm", callback?: () => void): void;
}>();

const isDialogOpen = ref(props.isOpen);

watch(
  () => props.isOpen,
  (newVal) => {
    isDialogOpen.value = newVal;
  }
);

watch(isDialogOpen, (newVal) => {
  emit("update:isOpen", newVal);
});

const iconMapper = computed(() => {
  const iconMap: Record<string, { name: string; color: string; btn: string }> =
    {
      info: { name: "info_outline", color: "info", btn: "ok" },
      warning: { name: "warning_amber", color: "warning", btn: "yes-no" },
      error: { name: "error_outline", color: "negative", btn: "ok" },
      matchFound: { name: "info_outline", color: "info", btn: "yes-no" }
    };
  return iconMap[props.type] || { name: "", color: "", btn: "" };
});

const confirm = () => {
  if (props.type === "warning" || props.type === "matchFound") {
    emit("confirm");
  }
  closeDialog();
};

const closeDialog = () => {
  isDialogOpen.value = false;
};
</script>

<template>
  <QDialog v-model="isDialogOpen">
    <QCard style="min-width: 300px">
      <div
        class="row items-center q-pl-sm q-pb-sm q-pt-md bg-primary text-white"
      >
        <QIcon
          :name="iconMapper.name"
          :color="iconMapper.color"
          size="2rem"
          class="q-pr-sm"
        />
        <div class="text-h6">{{ title }}</div>
      </div>
      <QCardSection>
        <div class="row items-center">
          <div class="text-subtitle2" style="white-space: pre-line">
            {{ message }}
          </div>
        </div>
      </QCardSection>
      <QCardActions align="right">
        <QBtn
          v-if="iconMapper.btn === 'ok'"
          flat
          label="Ok"
          color="info"
          @click="closeDialog"
        />
        <QBtn
          v-if="iconMapper.btn === 'yes-no'"
          flat
          label="No"
          color="negative"
          @click="closeDialog"
        />
        <QBtn
          v-if="iconMapper.btn === 'yes-no'"
          flat
          label="Yes"
          color="positive"
          @click="confirm"
        />
      </QCardActions>
    </QCard>
  </QDialog>
</template>
